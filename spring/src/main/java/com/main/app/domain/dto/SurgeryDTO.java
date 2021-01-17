package com.main.app.domain.dto;

import com.main.app.domain.model.Surgery;

import java.time.Instant;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@Getter
@Setter
public class SurgeryDTO {

    private Long id;
    private Instant date;
    private String description;
    private HallDTO hall;
    private UserDTO doctor;
    private UserDTO patient;
    private ClinicDTO clinic;

    public SurgeryDTO(Surgery surgery) {
        this.id = surgery.getId();
        this.date = surgery.getDate();
        this.description = surgery.getDescription();
        this.hall = new HallDTO(surgery.getHall());
        this.doctor = new UserDTO(surgery.getDoctor());
        this.patient = new UserDTO(surgery.getPatient());
        this.clinic = new ClinicDTO(surgery.getClinic());
    }

}
