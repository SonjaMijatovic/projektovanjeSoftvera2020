package com.main.app.service;

import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.user.User;
import org.springframework.data.domain.Pageable;

import java.util.List;

public interface AppointmentService {

    List<Appointment> findAllByClinic(Clinic clinic, Pageable pageable);
    List<Appointment> findAllByPatient(User patient, Pageable pageable);

    Appointment save(Appointment appointment);
}
