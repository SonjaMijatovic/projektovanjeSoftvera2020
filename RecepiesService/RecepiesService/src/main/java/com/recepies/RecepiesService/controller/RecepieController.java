package com.recepies.RecepiesService.controller;

import com.recepies.RecepiesService.model.Database;
import com.recepies.RecepiesService.model.Recepie;
import com.recepies.RecepiesService.model.Recepies;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.xml.crypto.Data;

@RestController
@RequestMapping("/recepies")
public class RecepieController {

    @GetMapping(path = "/{patientId}")
    public ResponseEntity<Recepies> get(@PathVariable int patientId) {

        return new ResponseEntity<Recepies>(Database.getInstance().getRecepies(), HttpStatus.OK);

    }
    
    @GetMapping(path = "/all")
    public ResponseEntity<Recepies> get() {

        return new ResponseEntity<Recepies>(Database.getInstance().getRecepies(), HttpStatus.OK);

    }

    @PostMapping(path ="/")
    public ResponseEntity<Recepie> add(@RequestBody Recepie recepie) {

        Database.getInstance().getRecepies().getRecepies().add(recepie);
        Database.getInstance().save();

        return new ResponseEntity<Recepie>(recepie, HttpStatus.OK);
    }

}
