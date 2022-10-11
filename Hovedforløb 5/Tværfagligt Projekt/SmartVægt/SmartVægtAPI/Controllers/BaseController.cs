﻿using Microsoft.AspNetCore.Mvc;
using SmartWeightLib.Database;
using SmartWeightLib.Models;
using System.Net;

namespace SmartWeightAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly SmartWeightDbContext _context;
        protected readonly Dictionary<Endpoints, string> _endpoints = new()
        {
            {Endpoints.CONNECTIONS, "connections"},
            {Endpoints.MEASUREMENTS, "measurements"},
            {Endpoints.PARTIAL_MEASUREMENTS, "measurements/partials"},
            {Endpoints.USERS, "users"}
        };
        
        public BaseController(SmartWeightDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Checks if there's a connection between any ids, and if so, add the measurement to the database
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <param name="type">user | weight</param>
        protected IActionResult HandleMeasurement(int id, MeasurementPartialTypes type, IActionResult result)
        {
            // Is weight connected to a user, if not, then maybe user connects after weight was used
            Connection? conn =
                type == MeasurementPartialTypes.USER ? _context.Connections.First(c => c.UserId == id) :
                type == MeasurementPartialTypes.PARTIAL_MEASUREMENT ? _context.Connections.First(c => c.WeightId == id) :
                null;
            if (conn is null) return result;

            // Get partial measurement, if any
            PartialMeasurement? partialMeasurement = _context.PartialMeasurements.First(p => p.WeightId == conn.WeightId);
            if (partialMeasurement is null) return result;

            // Delete connection regardless of what happens next
            var client = new HttpClient();
            client.DeleteAsync($"{_endpoints[Endpoints.CONNECTIONS]}/{conn.Id}");

            // Get user from connection
            User user = _context.Users.First(u => u.Id == conn.UserId);
            if (user is null) return StatusCode(StatusCodes.Status500InternalServerError, "User not found - connection is corrupted");

            // Save measurement
            var measurement = new Measurement(
                conn.UserId, 
                partialMeasurement.WeightId, 
                partialMeasurement.Weight, 
                partialMeasurement.Date);
            HttpResponseMessage? posted = client.PostAsync($"{_endpoints[Endpoints.MEASUREMENTS]}", new JsonContent(measurement)).Result;

            // Delete partial measurement
            client.DeleteAsync($"{_endpoints[Endpoints.PARTIAL_MEASUREMENTS]}/{partialMeasurement.Id}");

            return posted.StatusCode == HttpStatusCode.OK ?
                Ok("Measurement saved.") :
                StatusCode(StatusCodes.Status500InternalServerError, "Failed to save measurement.");
        }
    }
}
