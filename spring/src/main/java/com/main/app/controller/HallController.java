package com.main.app.controller;

import com.main.app.domain.dto.Entities;
import com.main.app.domain.dto.HallDTO;
import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.Hall;
import com.main.app.repository.user.ClinicRepository;
import com.main.app.service.HallService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/hall")
public class HallController {

    private HallService hallService;
    private ClinicRepository clinicRepository;

    @Autowired
    public HallController(HallService hallService, ClinicRepository clinicRepository) {
        this.hallService = hallService;
        this.clinicRepository = clinicRepository;
    }

    @GetMapping(path="/")
    public ResponseEntity<Entities> findAllByClinic(Pageable pageable, @RequestParam(name = "clinicId") Long clinicId) {

        Clinic clinic = clinicRepository.findById(clinicId).get();

        Entities result = new Entities();
        result.setEntities(hallService.findAllByClinic(clinic, pageable));

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @PostMapping(path="/")
    public ResponseEntity<HallDTO> add(@RequestBody HallDTO hallDTO) {

        Hall saved = hallService.save(new Hall(hallDTO));
        return new ResponseEntity<>(new HallDTO(saved), HttpStatus.OK);
    }
}