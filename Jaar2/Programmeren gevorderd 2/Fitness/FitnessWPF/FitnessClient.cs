using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FitnessWPF.Excepitons;

using FitnessWPF.Model;
using Newtonsoft.Json;

namespace FitnessWPF
{
    public class FitnessClient
    {
        // Statische HttpClient instantie om hergebruik te optimaliseren
        static HttpClient client = new HttpClient();

        // Constructor die de basisconfiguratie van de HttpClient instelt
        public FitnessClient()
        {
            // Stel de basis-URI in voor API-aanroepen
            client.BaseAddress = new Uri("https://localhost:7240/");

            // Maak headers leeg en stel Accept-header in op JSON
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        // Haalt een lijst van leden op aan de hand van voornaam en achternaam
        public async Task<List<Member>> GetMember(string voornaam, string achternaam)
        {
            try
            {
                // API-aanroep om leden te zoeken op naam
                HttpResponseMessage response = await client.GetAsync(
                    $"/MemberViaNaam/{voornaam}/{achternaam}"
                );
                response.EnsureSuccessStatusCode(); // Controleer op successtatus

                // Lees en deserialiseer de JSON-response naar een lijst van leden
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Member>? members = JsonConvert.DeserializeObject<List<Member>>(responseBody);

                return members; // Geef de lijst van leden terug
            }
            catch (Exception ex)
            {
                // Gooi een specifieke uitzondering als er een fout optreedt
                throw new FitnessClientException($"Error on retrieving members: {ex.Message}", ex);
            }
        }

        // Haalt reserveringen op die een lid heeft gemaakt
        public async Task<List<Reservation>> GetReservationsMember(Member member)
        {
            try
            {
                int id = member.Member_id; // Haal lid-ID op
                HttpResponseMessage response = await client.GetAsync($"/ReservationsMember/{id}");
                response.EnsureSuccessStatusCode(); // Controleer op successtatus

                // Lees en deserialiseer de JSON-response naar een lijst van reserveringen
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Reservation>? reservations = JsonConvert.DeserializeObject<List<Reservation>>(
                    responseBody
                );

                return reservations; // Geef de lijst van reserveringen terug
            }
            catch (Exception ex)
            {
                // Gooi een specifieke uitzondering als er een fout optreedt
                throw new FitnessClientException(
                    $"Error on retrieving reservations that a member made: {ex.Message}",
                    ex
                );
            }
        }

        // Haalt alle beschikbare tijdsloten op
        public async Task<List<Time_slot>> GetTimeSlots()
        {
            try
            {
                // API-aanroep voor tijdsloten
                HttpResponseMessage response = await client.GetAsync($"/LijstTimeSlots");
                response.EnsureSuccessStatusCode(); // Controleer op successtatus

                // Lees en deserialiseer de JSON-response naar een lijst van tijdsloten
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Time_slot>? timeSlots = JsonConvert.DeserializeObject<List<Time_slot>>(
                    responseBody
                );

                return timeSlots; // Geef de lijst van tijdsloten terug
            }
            catch (Exception ex)
            {
                // Gooi een specifieke uitzondering als er een fout optreedt
                throw new FitnessClientException(
                    $"Error on retrieving time slots: {ex.Message}",
                    ex
                );
            }
        }

        // Haalt een specifiek tijdslot op aan de hand van het ID
        public async Task<Time_slot> GetTimeSlotId(int id)
        {
            try
            {
                // API-aanroep voor tijdslot op basis van ID
                HttpResponseMessage response = await client.GetAsync($"/Time_slotViaId/{id}");
                response.EnsureSuccessStatusCode(); // Controleer op successtatus

                // Lees en deserialiseer de JSON-response naar een tijdslot object
                string responseBody = await response.Content.ReadAsStringAsync();
                Time_slot? timeslot = JsonConvert.DeserializeObject<Time_slot>(responseBody);

                return timeslot; // Geef het tijdslot object terug
            }
            catch (Exception ex)
            {
                // Gooi een specifieke uitzondering als er een fout optreedt
                throw new FitnessClientException(
                    $"Error on retrieving the timeslot that correspondend with the id: {ex.Message}",
                    ex
                );
            }
        }

        // Haalt beschikbare apparatuur op voor een specifieke datum en tijdslot
        public async Task<List<Equipment>> GetAvailableEquipment(DateTime date, int TimeSlotId)
        {
            try
            {
                string formattedDate = date.ToString("yyyy-MM-dd"); // Formatteer de datum
                HttpResponseMessage response = await client.GetAsync(
                    $"/AllAvailableEquipment/{formattedDate}/{TimeSlotId}"
                );
                response.EnsureSuccessStatusCode(); // Controleer op successtatus

                // Lees en deserialiseer de JSON-response naar een lijst van apparatuur
                string responseBody = await response.Content.ReadAsStringAsync();
                List<Equipment> equipments = JsonConvert.DeserializeObject<List<Equipment>>(responseBody);

                return equipments; // Geef de lijst van apparatuur terug
            }
            catch (Exception ex)
            {
                // Gooi een specifieke uitzondering als er een fout optreedt
                throw new FitnessClientException(
                    $"Error on retrieving available equipments: {ex.Message}",
                    ex
                );
            }
        }

        // Maakt een nieuwe reservering aan
        public async Task<string> CreateReservation(ReservationAanmakenDTO reservation)
        {
            try
            {
                // Serializeer de reservering naar JSON
                string json = JsonConvert.SerializeObject(reservation);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // API-aanroep voor het aanmaken van een reservering
                HttpResponseMessage response = await client.PostAsync(
                    "/Reservation",
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    return null; // Geen foutmelding bij succes
                }
                else
                {
                    // Lees de foutmelding uit de response body
                    string error = await response.Content.ReadAsStringAsync();
                    return error;
                }
            }
            catch (Exception ex)
            {
                // Gooi een specifieke uitzondering als er een fout optreedt
                throw new FitnessClientException(
                    $"Error on creating the new reservation: {ex.Message}",
                    ex
                );
            }
        }
    }
}
