﻿using PSV.Model;
using PSV.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSV.Service
{
    public class AppointmentService
    {
        public Appointment Add(Appointment appointment)
        {
            if (appointment == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    appointment.DateCreated = DateTime.Now;
                    appointment.DateUpdated = DateTime.Now;
                    appointment.Deleted = false;
                    appointment.IsFree = true;

                    if (appointment.Doctor != null)
                    {
                        appointment.Doctor = unitOfWork.Users.Get(appointment.Doctor.Id);
                    }

                    if (appointment.Patient != null)
                    {
                        appointment.Patient = unitOfWork.Users.Get(appointment.Patient.Id);
                    }

                    unitOfWork.Appointments.Add(appointment);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return appointment;
        }

        public PageResponse<Appointment> GetPage(PageModel model, long from, long to, int doctorId, string type)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    return unitOfWork.Appointments.GetPage(model, from, to, doctorId, type);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Reserve(int id, User user)
        {
 
            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    Appointment appointment = unitOfWork.Appointments.Get(id);

                    if (appointment == null)
                    {
                        return;
                    }

                    appointment.Patient = user;
                    appointment.IsFree = false;
                    unitOfWork.Context.Appointments.Attach(appointment);
                    unitOfWork.Context.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e) { }
        }

        public void Cancel(int id)
        {

            try
            {
                using (var unitOfWork = new UnitOfWork(new BackendContext()))
                {
                    Appointment appointment = unitOfWork.Appointments.Get(id);

                    if (appointment == null)
                    {
                        return;
                    }

                    appointment.Patient = null;
                    appointment.IsFree = true;
                    unitOfWork.Context.Appointments.Attach(appointment);
                    unitOfWork.Context.Entry(appointment).State = System.Data.Entity.EntityState.Modified;
                    unitOfWork.Complete();
                }
            }
            catch (Exception e) { }
        }



    }
}
