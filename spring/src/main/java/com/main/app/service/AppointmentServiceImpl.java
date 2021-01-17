package com.main.app.service;

import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.user.User;
import com.main.app.repository.user.AppointmentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AppointmentServiceImpl implements AppointmentService {

    private AppointmentRepository appointmentRepository;

    @Autowired
    AppointmentServiceImpl(AppointmentRepository appointmentRepository) {
        this.appointmentRepository = appointmentRepository;
    }

    @Override
    public List<Appointment> findAllByClinic(Clinic clinic, Pageable pageable) {
        return appointmentRepository.findAllByClinic(clinic, pageable);
    }

    @Override
    public List<Appointment> findAllByPatient(User patient, Pageable pageable) {
        return appointmentRepository.findAllByPatient(patient, pageable);
    }

    @Override
    public Appointment save(Appointment appointment) {
        return appointmentRepository.save(appointment);
    }
}
