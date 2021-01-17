package com.main.app.controller;

import com.main.app.domain.dto.Entities;
import com.main.app.domain.dto.RecordDTO;
import com.main.app.domain.model.Record;
import com.main.app.service.RecordService;
import com.main.app.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/record")
public class RecordController {

    private RecordService recordService;
    private UserService userService;

    @Autowired
    public RecordController(RecordService recordService, UserService userService) {
        this.recordService = recordService;
        this.userService = userService;
    }

    @GetMapping(path="/")
    public ResponseEntity<Entities> findAllByPatient(Pageable pageable) {

        Entities result = new Entities();

        Page<Record> records = recordService.findAllByPatient(userService.getCurrentUser().get(), pageable);
        result.setEntities(records.getContent());
        result.setTotal(records.getTotalElements());

        return new ResponseEntity<>(result, HttpStatus.OK);
    }

    @PostMapping(path="/")
    public ResponseEntity<RecordDTO> add(@RequestBody RecordDTO recordDTO) {

        Record saved = recordService.save(new Record(recordDTO));
        return new ResponseEntity<>(new RecordDTO(saved), HttpStatus.OK);
    }
}