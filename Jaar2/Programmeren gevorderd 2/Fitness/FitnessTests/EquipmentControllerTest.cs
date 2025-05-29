using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessAPI.Controllers;
using FitnessAPI.DTO;
using FitnessBL.Exceptions;
using FitnessBL.Interfaces;
using FitnessBL.Model;
using FitnessBL.Services;
using FitnessEF.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;

namespace FitnessTests
{
    public class EquipmentControllerTest
    {
        private readonly Mock<IEquipmentRepo> equipmentRepoMock;
        private readonly Mock<IReservationRepo> reservationRepoMock;
        private readonly Mock<IMemberRepo> memberRepoMock;

        private readonly EquipmentService equipmentService;
        private readonly ReservationService reservationService;
        private readonly MemberService memberService;

        private readonly EquipmentController controller;

        private Equipment equipment;

        public EquipmentControllerTest()
        {
            equipmentRepoMock = new Mock<IEquipmentRepo>();
            reservationRepoMock = new Mock<IReservationRepo>();
            memberRepoMock = new Mock<IMemberRepo>();

            memberService = new MemberService(memberRepoMock.Object);
            equipmentService = new EquipmentService(equipmentRepoMock.Object);
            reservationService = new ReservationService(
                reservationRepoMock.Object,
                memberService,
                equipmentService
            );

            controller = new EquipmentController(equipmentService, reservationService);

            equipment = new Equipment(1, "bike",false);
        }

        [Fact]
        public void GetEquipmentId_ServiceThrowsException_ReturnsBadRequest_FailingTest()
        {
            // Arrange
            int equipmentId = 1;

            // Mocks
            equipmentRepoMock
                .Setup(repo => repo.GetEquipmentId(equipmentId))
                .Returns((Equipment)null);

            // Act
            var result = controller.GetEquipmentId(equipmentId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result); // Verwacht een BadRequest
            Assert.Equal(
                "EquipmentService - GetEquipmentId - Er is geen equipment met dit id!",
                badRequestResult.Value
            ); // De exception message
        }

        [Fact]
        public void GetEquipmentId_ExistingId_ReturnsOkResult_WorkingTest()
        {
            // Arrange
            int equipmentId = 1;

            // Mocks
            equipmentRepoMock.Setup(repo => repo.GetEquipmentId(equipmentId)).Returns(equipment);

            // Act
            var result = controller.GetEquipmentId(equipmentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Verwacht een OkResult
            var returnValue = Assert.IsType<Equipment>(okResult.Value);
            Assert.Equal(equipmentId, returnValue.Equipment_id); // Verifieer dat het juiste equipment wordt geretourneerd
        }

        [Fact]
        public void AddEquipment_ServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            EquipmentAanmakenDTO equipmentDTO = new EquipmentAanmakenDTO
            {
                device_type = "string" // Dit veroorzaakt een exception in de service
            };

            // Act
            var result = controller.AddEquipment(equipmentDTO);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(
                "EquipmentService - AddEquipment - Gelieve het type van het equipment in te vullen!",
                badRequestResult.Value
            );
        }

        [Fact]
        public void AddEquipment_ServiceSucceeds_ReturnsCreatedAtAction()
        {
            // Arrange
            EquipmentAanmakenDTO equipmentDTO = new EquipmentAanmakenDTO { device_type = "bike" };

            Equipment equipment = new Equipment(equipmentDTO.device_type);

            // Stel de mock in om geen uitzondering te gooien
            equipmentRepoMock.Setup(repo => repo.AddEquipment(equipment)).Returns(equipment);

            // Act
            var result = controller.AddEquipment(equipmentDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Equipment returnedEquipment = Assert.IsType<Equipment>(createdAtActionResult.Value);
            Assert.Equal("bike", returnedEquipment.Device_type); // Check of het apparaat type klopt
        }

        [Fact]
        public void DeleteEquipment_ServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            int id = 2;
            equipmentRepoMock.Setup(repo => repo.GetEquipmentId(id)).Returns((Equipment)null);

            // Act
            var result = controller.DeleteEquipment(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(
                "EquipmentService - GetEquipmentId - Er is geen equipment met dit id!",
                badRequestResult.Value
            ); // Check of het juiste foutbericht wordt geretourneerd
        }

        

        [Fact]
        public void GetAllAvailableEquipment_InvalidDate_ThrowsFormatException_ReturnsBadRequest()
        {
            // Arrange
            string invalidDateAsString = "invalid-date";
            int timeSlotId = 1;

            // Act
            var result = controller.GetAllAvailableEquipment(invalidDateAsString, timeSlotId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains(
                "The string 'invalid-date' was not recognized as a valid DateTime.",
                badRequestResult.Value.ToString()
            );
            equipmentRepoMock.Verify(
                repo => repo.GetAllAvailableEquipment(It.IsAny<DateTime>(), timeSlotId),
                Times.Never
            );
        }

        [Fact]
        public void GetAllAvailableEquipment_PastDate_ThrowsFormatException_ReturnsBadRequest()
        {
            // Arrange
            string invalidDateAsString = "2025-01-01";
            int timeSlotId = 1;

            // Act
            var result = controller.GetAllAvailableEquipment(invalidDateAsString, timeSlotId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains(
                "EquipmentService - GetAvailableEquipment - Date moet in de toekomst liggen om te zien of dit equipment in de toekomst al gebruikt wordt!",
                badRequestResult.Value.ToString()
            );
            equipmentRepoMock.Verify(
                repo => repo.GetAllAvailableEquipment(It.IsAny<DateTime>(), timeSlotId),
                Times.Never
            );
        }

        [Fact]
        public void GetAllAvailableEquipment_NoEquipmentAvailable_ReturnsOkWithEmptyList()
        {
            // Arrange
            string dateAsString = "2025-01-27";
            int timeSlotId = 1;
            DateTime date = DateTime.Parse(dateAsString);
            var emptyList = new List<Equipment>();

            // Mocks
            equipmentRepoMock
                .Setup(repo => repo.GetAllAvailableEquipment(date, timeSlotId))
                .Returns(emptyList);

            // Act
            var result = controller.GetAllAvailableEquipment(dateAsString, timeSlotId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(emptyList, okResult.Value);
            equipmentRepoMock.Verify(
                repo => repo.GetAllAvailableEquipment(date, timeSlotId),
                Times.Once
            );
        }

        [Fact]
        public void GetAllAvailableEquipment_Successful_ReturnsOk()
        {
            // Arrange
            string dateAsString = "2025-01-28";
            int timeSlotId = 1;
            DateTime date = DateTime.Parse(dateAsString);
            List<Equipment> availableEquipments = new List<Equipment>
            {
                new Equipment(1, "bike", false),
                new Equipment(3, "bike", false)
            };

            // Mocks
            equipmentRepoMock
                .Setup(repo => repo.GetAllAvailableEquipment(date, timeSlotId))
                .Returns(availableEquipments);

            // Act
            var result = controller.GetAllAvailableEquipment(dateAsString, timeSlotId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(availableEquipments, okResult.Value);
            equipmentRepoMock.Verify(
                repo => repo.GetAllAvailableEquipment(date, timeSlotId),
                Times.Once
            );
        }
    }
}
