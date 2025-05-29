using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAPI.Controllers;
using FitnessAPI.DTO;
using FitnessBL.Enums;
using FitnessBL.Exceptions;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using FitnessBL.Services;
using FitnessEF.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FitnessTests
{
    public class ReservationControllerTest
    {
        private readonly Mock<IMemberRepo> memberRepoMock;
        private readonly Mock<IReservationRepo> reservationRepoMock;
        private readonly Mock<IEquipmentRepo> equipmentRepoMock;
        private readonly Mock<ITime_slotRepo> timeSlotRepoMock;

        private readonly MemberService memberService;
        private readonly ReservationService reservatieService;
        private readonly EquipmentService equipmentService;
        private readonly Time_slotService timeSlotService;

        private readonly ReservationController controller;
        private Reservation reservation;
        private Member member;
        private DateTime date;

        public ReservationControllerTest()
        {
            memberRepoMock = new Mock<IMemberRepo>();
            reservationRepoMock = new Mock<IReservationRepo>();
            equipmentRepoMock = new Mock<IEquipmentRepo>();
            timeSlotRepoMock = new Mock<ITime_slotRepo>();

            memberService = new MemberService(memberRepoMock.Object);
            equipmentService = new EquipmentService(equipmentRepoMock.Object);

            timeSlotService = new Time_slotService(timeSlotRepoMock.Object);
            reservatieService = new ReservationService(
                reservationRepoMock.Object,
                memberService,
                equipmentService
            );

            controller = new ReservationController(
                reservatieService,
                memberService,
                equipmentService,
                timeSlotService
            );

            member = new Member(
                1,
                "John",
                "Doe",
                "john.doe@example.com",
                "Some Street 123",
                new DateTime(1990, 1, 1),
                new List<string> { "Fitness", "Swimming" },
                TypeKlant.Gold
            );

            date = new DateTime(2025, 1, 12);
            Dictionary<Time_slot, Equipment> dic = new Dictionary<Time_slot, Equipment>();
            reservation = new Reservation(1, date, member, dic);
        }

        [Fact]
        public void GetReservationID_ReservationExists_ReturnsOkResult()
        {
            // Mocks
            reservationRepoMock
                .Setup(repo => repo.GetReservationId(reservation.Reservation_id))
                .Returns(reservation);
            reservationRepoMock.Setup(repo => repo.IsReservationId(reservation)).Returns(true);

            // Act
            var result = controller.GetReservationID(reservation.Reservation_id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Reservation>(okResult.Value);
            Assert.Equal(reservation.Reservation_id, returnValue.Reservation_id);
        }

        [Fact]
        public void GetReservationID_ReservationNotFound_ReturnsNotFoundResult()
        {
            // Arrange
            var reservationId = 1;

            reservationRepoMock
                .Setup(repo => repo.GetReservationId(reservationId))
                .Returns((Reservation)null);
            reservationRepoMock.Setup(repo => repo.IsReservationId(reservation)).Returns(false);

            // Act
            var result = controller.GetReservationID(reservationId);

            // Assert
            var expectedResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(
                "ReservationService - GetReservationId - Er is geen Reservation met dit Id ",
                expectedResult.Value
            );
        }

        [Fact]
        public void CreateReservation_Success_ReturnsCreatedAtActionResult()
        {
            // Arrange
            ReservationAanmakenDTO reservationDTO = new ReservationAanmakenDTO
            {
                MemberId = 1,
                Date = DateTime.Now,
                EquipmentPerTimeslot = new List<TimeslotEquipmentDTO>
                {
                    new TimeslotEquipmentDTO { Time_slot_id = 1, Equipment_id = 1 }
                }
            };

            Time_slot timeSlot = new Time_slot(1, 8, 9, "Morning");
            Equipment equipment = new Equipment(1, "Bike", false);

            timeSlotRepoMock.Setup(repo => repo.GetTime_slotId(It.IsAny<int>())).Returns(timeSlot);
            equipmentRepoMock
                .Setup(repo => repo.GetEquipmentId(It.IsAny<int>()))
                .Returns(equipment);
            equipmentRepoMock.Setup(repo => repo.IsEquipmentId(equipment)).Returns(true);
            memberRepoMock.Setup(repo => repo.GetMemberId(It.IsAny<int>())).Returns(member);
            memberRepoMock.Setup(repo => repo.IsMemberId(member)).Returns(true);
            reservationRepoMock.Setup(repo => repo.GetNieuwReservationId()).Returns(2);
            reservationRepoMock.Setup(repo => repo.AddReservation(It.IsAny<Reservation>()));

            // Act
            var result = controller.CreateReservation(reservationDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<Reservation>(createdAtActionResult.Value);
            Assert.Equal(2, returnValue.Reservation_id);
        }

        [Fact]
        public void CreateReservation_MemberException_ReturnsBadRequest()
        {
            // Arrange
            var reservationDTO = new ReservationAanmakenDTO
            {
                MemberId = 1,
                Date = DateTime.Now,
                EquipmentPerTimeslot = new List<TimeslotEquipmentDTO>
                {
                    new TimeslotEquipmentDTO { Time_slot_id = 1, Equipment_id = 1 }
                }
            };

            Time_slot time_Slot = new Time_slot(1, 8, 9, "Morning");
            Equipment equipment = new Equipment(1, "bike", false);

            timeSlotRepoMock
                .Setup(repo => repo.GetTime_slotId(time_Slot.Time_slot_id))
                .Returns(time_Slot);

            equipmentRepoMock
                .Setup(repo => repo.GetEquipmentId(equipment.Equipment_id))
                .Returns(equipment);
            equipmentRepoMock.Setup(repo => repo.IsEquipmentId(equipment)).Returns(true);

            memberRepoMock.Setup(repo => repo.GetMemberId(It.IsAny<int>())).Returns((Member)null);
            memberRepoMock.Setup(repo => repo.IsMemberId(member)).Returns(false);

            // Act
            var result = controller.CreateReservation(reservationDTO);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(
                "MemberService - GetMemberId - Er is geen member met dit id!",
                badRequestResult.Value
            );
        }

        [Fact]
        public void UpdateReservationTimeSlots_Success_ReturnsCreatedAtActionResult()
        {
            // Arrange - Instellen van de testomgeving

            // Maak een ReservationAanpassenDTO object met een lijst van TimeslotEquipmentDTO's
            var tseDTOs = new ReservationAanpassenDTO
            {
                TimeslotEquipment = new List<TimeslotEquipmentDTO>
        {
            new TimeslotEquipmentDTO { Time_slot_id = 1, Equipment_id = 1 }
        }
            };

            // Maak een mock Time_slot object dat de mock repository zal retourneren
            Time_slot time_Slot = new Time_slot(1, 8, 9, "Morning");

            // Maak een mock Equipment object dat de mock repository zal retourneren
            Equipment equipment = new Equipment(1, "bike", false);

            // Stel de mock voor de ReservationRepository in om een bestaand Reservation object terug te geven
            reservationRepoMock
                .Setup(repo => repo.GetReservationId(It.IsAny<int>()))
                .Returns(reservation); // Simuleert dat een Reservation object wordt opgehaald uit de database

            // Controleer of de reservationId geldig is
            reservationRepoMock.Setup(repo => repo.IsReservationId(reservation)).Returns(true);

            // Stel de mock voor de TimeSlotRepository in om een specifiek Time_slot object terug te geven
            timeSlotRepoMock.Setup(repo => repo.GetTime_slotId(It.IsAny<int>())).Returns(time_Slot);

            // Stel de mock voor de EquipmentRepository in om een specifiek Equipment object terug te geven
            equipmentRepoMock
                .Setup(repo => repo.GetEquipmentId(It.IsAny<int>()))
                .Returns(equipment);

            // Controleer of het equipmentId geldig is
            equipmentRepoMock.Setup(repo => repo.IsEquipmentId(equipment)).Returns(true);

            // Act - Voer de methode uit die wordt getest
            var result = controller.UpdateReservationTimeSlots(1, tseDTOs);

            // Assert - Controleer of het resultaat is zoals verwacht

            // Controleer of het resultaat een CreatedAtActionResult is
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);

            // Controleer of de waarde binnen het CreatedAtActionResult van het juiste type is
            var returnValue = Assert.IsType<Reservation>(createdAtActionResult.Value);

            // Controleer of de reservation_id van het geretourneerde Reservation object correct is
            Assert.Equal(1, returnValue.Reservation_id);

            // Controleer of het TimeslotEquipment object in de geretourneerde Reservation de juiste data bevat
            Assert.Contains(
                returnValue.TimeslotEquipment,
                kvp => kvp.Key == time_Slot && kvp.Value == equipment
            );
        }


        [Fact]
        public void UpdateReservationTimeSlots_ReservationNotFound_ReturnsNotFound()
        {
            // Arrange
            // Maak een ReservationAanpassenDTO object met een lijst van TimeslotEquipmentDTO's
            var tseDTOs = new ReservationAanpassenDTO
            {
                TimeslotEquipment = new List<TimeslotEquipmentDTO>
        {
            new TimeslotEquipmentDTO { Time_slot_id = 1, Equipment_id = 1 }
        }
            };

            reservationRepoMock
                .Setup(repo => repo.GetReservationId(It.IsAny<int>()))
                .Returns((Reservation)null);

            // Act
            var result = controller.UpdateReservationTimeSlots(1, tseDTOs);

            // Assert
            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(
                "ReservationService - GetReservationId - Er is geen Reservation met dit Id ",
                notFoundResult.Value
            );
        }

        [Fact]
        public void DeleteReservation_ReturnsOk_WhenReservationIsDeleted()
        {
            // Arrange
            int reservationId = 1;

            // Mocks
            reservationRepoMock
                .Setup(repo => repo.GetReservationId(reservationId))
                .Returns(reservation);
            reservationRepoMock.Setup(repo => repo.IsReservationId(reservation)).Returns(true);

            // Act
            var result = controller.DeleteReservation(reservationId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"De reservation is succesvol verwijderd!", okResult.Value);
        }

        [Fact]
        public void DeleteReservation_ReturnsNotFound_WhenReservationDoesNotExist()
        {
            // Arrange
            int reservationId = 1;

            // Mocks
            reservationRepoMock
                .Setup(s => s.GetReservationId(reservationId))
                .Returns((Reservation)null);

            // Act
            var result = controller.DeleteReservation(reservationId);

            // Assert
            var notFoundResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(
                $"ReservationService - GetReservationId - Er is geen Reservation met dit Id ",
                notFoundResult.Value
            );
            reservationRepoMock.Verify(
                s => s.DeleteReservation(It.IsAny<Reservation>()),
                Times.Never
            );
        }
    }
}
