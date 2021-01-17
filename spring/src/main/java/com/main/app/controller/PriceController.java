package com.main.app.controller;

import com.main.app.domain.dto.Entities;
import com.main.app.domain.dto.PriceDTO;
import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.Price;
import com.main.app.repository.user.ClinicRepository;
import com.main.app.service.PriceService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/price")
public class PriceController {

    private PriceService priceService;
    private ClinicRepository clinicRepository;

    @Autowired
    public PriceController(PriceService priceService, ClinicRepository clinicRepository) {
        this.priceService = priceService;
        this.clinicRepository = clinicRepository;
    }

    @GetMapping(path="/")
    public ResponseEntity<Entities> findAllByClinic(Pageable pageable, @RequestParam(name = "clinicId") Long clinicId) {

        Clinic clinic = clinicRepository.findById(clinicId).get();

        Entities result = new Entities();
        result.setEntities(priceService.findAllByClinic(clinic, pageable));

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @PostMapping(path="/")
    public ResponseEntity<PriceDTO> add(@RequestBody PriceDTO priceDTO) {

        Price saved = priceService.save(new Price(priceDTO));
        return new ResponseEntity<>(new PriceDTO(saved), HttpStatus.OK);
    }
}