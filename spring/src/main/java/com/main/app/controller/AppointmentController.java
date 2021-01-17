package com.main.app.controller;

import com.main.app.domain.dto.AppointmentDTO;
import com.main.app.domain.dto.Entities;
import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Clinic;
import com.main.app.repository.user.ClinicRepository;
import com.main.app.service.AppointmentService;
import com.main.app.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/appointment")
public class AppointmentController {

    private AppointmentService appointmentService;
    private UserService userService;
    private ClinicRepository clinicRepository;

    @Autowired
    public AppointmentController(AppointmentService appointmentService, UserService userService, ClinicRepository clinicRepository) {
        this.appointmentService = appointmentService;
        this.userService = userService;
        this.clinicRepository = clinicRepository;
    }

    @GetMapping(path="/")
    public ResponseEntity<Entities> findAllByClinic(Pageable pageable, @RequestParam(name = "clinicId") Long clinicId) {

        Clinic clinic = clinicRepository.findById(clinicId).get();

        Entities result = new Entities();
        result.setEntities(appointmentService.findAllByClinic(clinic, pageable));

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @GetMapping(path="/patient")
    public ResponseEntity<Entities> findAllByPatient(Pageable pageable) {

        Entities result = new Entities();
        result.setEntities(appointmentService.findAllByPatient(userService.getCurrentUser().get(), pageable));

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @PostMapping(path="/")
    public ResponseEntity<AppointmentDTO> add(@RequestBody AppointmentDTO appointmentDTO) {

        Appointment saved = appointmentService.save(new Appointment(appointmentDTO));
        return new ResponseEntity<>(new AppointmentDTO(saved), HttpStatus.OK);
    }
}
