package com.main.app.controller;

import com.main.app.domain.dto.Entities;
import com.main.app.domain.dto.SurgeryDTO;
import com.main.app.domain.model.Surgery;
import com.main.app.service.SurgeryService;
import com.main.app.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;


@RestController
@RequestMapping("/api/surgery")
public class SurgeryController {

    private SurgeryService surgeryService;
    private UserService userService;

    @Autowired
    public SurgeryController(SurgeryService surgeryService, UserService userService) {
        this.surgeryService = surgeryService;
        this.userService = userService;
    }

    @GetMapping(path="/")
    public ResponseEntity<Entities> findAllByPatient(Pageable pageable) {

        Entities result = new Entities();

        Page<Surgery> surgeries = surgeryService.findAllByPatient(userService.getCurrentUser().get(), pageable);

        result.setEntities(surgeries.getContent());
        result.setTotal(surgeries.getTotalElements());

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @PostMapping(path="/")
    public ResponseEntity<SurgeryDTO> add(@RequestBody SurgeryDTO surgeryDTO) {

        Surgery saved = surgeryService.save(new Surgery(surgeryDTO));
        return new ResponseEntity<>(new SurgeryDTO(saved), HttpStatus.OK);
    }
}
