using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNutricion.Models;

namespace WebNutricion.Controllers
{
    public class AppointmentController : Controller
    {
        // Action for user view to fetch available dates and times
        public ActionResult AvailableAppointments()
        {
            List<Appointment> appointments = GetAvailableAppointments();
            return View(appointments);
        }

        // Action for admin view to manage appointments
        public ActionResult AdminAppointments()
        {
            List<Appointment> appointments = GetAllAppointments();
            return View(appointments);
        }

        // Action to book an appointment
        [HttpPost]
        public ActionResult BookAppointment(int id)
        {
            // Update the status of the appointment to booked
            if (UpdateAppointmentStatus(id, "Booked"))
            {
                TempData["Message"] = "Appointment booked successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to book appointment.";
            }

            return RedirectToAction("AvailableAppointments");
        }

        // Action to accept an appointment
        [HttpPost]
        public ActionResult AcceptAppointment(int id)
        {
            // Update the status of the appointment to accepted
            if (UpdateAppointmentStatus(id, "Accepted"))
            {
                TempData["Message"] = "Appointment accepted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to accept appointment.";
            }

            return RedirectToAction("AdminAppointments");
        }

        // Action to delete an appointment
        [HttpPost]
        public ActionResult DeleteAppointment(int id)
        {
            // Delete the appointment from the database
            if (DeleteAppointmentById(id))
            {
                TempData["Message"] = "Appointment deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to delete appointment.";
            }

            return RedirectToAction("AdminAppointments");
        }

        // Action to propose a new time for an appointment
        [HttpPost]
        public ActionResult ProposeNewTime(int id, DateTime newDate, string newTime)
        {
            // Update the appointment with the new date and time
            if (UpdateAppointmentDateTime(id, newDate, newTime))
            {
                TempData["Message"] = "New time proposed successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to propose new time.";
            }

            return RedirectToAction("AdminAppointments");
        }


        private List<Appointment> GetAvailableAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            // Assume you have a connection string named "ConnectionString" in your Web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Appointments WHERE Status = 'Available'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Time = reader["Time"].ToString(),
                            User = reader["User"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        appointments.Add(appointment);
                    }
                }
            }

            return appointments;
        }

        private List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            // Assume you have a connection string named "ConnectionString" in your Web.config
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Appointments";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Appointment appointment = new Appointment
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Time = reader["Time"].ToString(),
                            User = reader["User"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        appointments.Add(appointment);
                    }
                }
            }

            return appointments;
        }

        private bool UpdateAppointmentStatus(int appointmentId, string status)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Appointments SET Status = @Status WHERE Id = @AppointmentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private bool DeleteAppointmentById(int appointmentId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Appointments WHERE Id = @AppointmentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        private bool UpdateAppointmentDateTime(int appointmentId, DateTime newDate, string newTime)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Appointments SET Date = @NewDate, Time = @NewTime WHERE Id = @AppointmentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewDate", newDate);
                    command.Parameters.AddWithValue("@NewTime", newTime);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}
