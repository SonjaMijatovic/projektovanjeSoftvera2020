package com.main.app.controller;

import com.main.app.domain.dto.ClinicDTO;
import com.main.app.domain.dto.Entities;
import com.main.app.domain.model.Clinic;
import com.main.app.service.ClinicService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/clinic")
public class ClinicController {

    private ClinicService clinicService;

    @Autowired
    public ClinicController(ClinicService clinicService) {
        this.clinicService = clinicService;
    }

    @GetMapping(path="/")
    public ResponseEntity<Entities> findAllByPatient(Pageable pageable) {


        Entities result = new Entities();

        Page<Clinic> clinics = clinicService.findAll(pageable);

        result.setEntities(clinics.getContent());
        result.setTotal(clinics.getTotalElements());

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @PostMapping(path="/")
    public ResponseEntity<ClinicDTO> add(@RequestBody ClinicDTO clinicDTO) {

        Clinic saved = clinicService.save(new Clinic(clinicDTO));
        return new ResponseEntity<>(new ClinicDTO(saved), HttpStatus.OK);
    }
}