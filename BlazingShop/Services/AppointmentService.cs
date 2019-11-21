using BlazingShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazingShop.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Appointment> GetAppointments()
        {
            return _db.Appointments.Include(p => p.Product).ToList();
        }

        public List<Product> GetProductList()
        {
            return _db.Products.ToList();
        }

        public bool CreateAppointment(Appointment appointment)
        {
            //Do not want the save to try to save to Categories
            appointment.ProductId = appointment.Product.Id;
            appointment.Product = null;

            _db.Appointments.Add(appointment);
            _db.SaveChanges();

            return true;
        }

        public bool ConfirmAppointment(Appointment appointment)
        {
            var existingAppointment = _db.Appointments.FirstOrDefault(a => a.Id == appointment.Id);

            if (existingAppointment != null)
            {
                existingAppointment.IsConfirmed = true;
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool UpdateAppointment(Appointment objAppointment)
        {
            Appointment ExistingAppointment = _db.Appointments.FirstOrDefault(c => c.Id == objAppointment.Id);

            if (ExistingAppointment != null)
            {
                _db.Appointments.Update(objAppointment);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            var ExistingAppointment = _db.Appointments.FirstOrDefault(a => a.Id == appointment.Id);

            if (ExistingAppointment != null)
            {
                _db.Remove(ExistingAppointment);
                _db.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
