package com.main.app.domain.model;

import com.main.app.domain.dto.ClinicDTO;
import com.main.app.domain.dto.HallDTO;
import com.main.app.domain.dto.SurgeryDTO;
import com.main.app.domain.dto.UserDTO;
import com.main.app.domain.model.user.User;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import javax.persistence.*;
import javax.validation.constraints.NotNull;
import java.time.Instant;

@Entity
@NoArgsConstructor
@Getter
@Setter
public class Surgery extends  AbstractEntity {

    private Instant date;
    private  String description;

    @ManyToOne
    private Hall hall;

    @ManyToOne
    private User doctor;

    @ManyToOne
    private User patient;

    @ManyToOne
    private Clinic clinic;

    public Surgery(Instant date, Hall hall, User doctor, User patient, String description, Clinic clinic) {

        this.date = date;
        this.hall = hall;
        this.doctor = doctor;
        this.patient = patient;
        this.description = description;
        this.clinic = clinic;
    }

    public Surgery(SurgeryDTO surgery) {
        this.id = surgery.getId();
        this.date = surgery.getDate();
        this.description = surgery.getDescription();
        this.hall = new Hall(surgery.getHall());
        this.doctor = new User(surgery.getDoctor());
        this.patient = new User(surgery.getPatient());
        this.clinic = new Clinic(surgery.getClinic());
    }
}
