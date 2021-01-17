package com.main.app.domain.dto;

import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Surgery;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.Instant;

@NoArgsConstructor
@Getter
@Setter
public class AppointmentDTO {

    private Long id;
    private Instant date;
    private String type;
    private double price;
    private boolean isTaken;
    private String description;
    private HallDTO hall;
    private UserDTO doctor;
    private UserDTO patient;
    private ClinicDTO clinic;

    public AppointmentDTO(Appointment appointment) {
        this.id = appointment.getId();
        this.date = appointment.getDate();
        this.type = appointment.getType();
        this.price = appointment.getPrice();
        this.isTaken = appointment.isTaken();
        this.description = appointment.getDescription();
        this.hall = new HallDTO(appointment.getHall());
        this.doctor = new UserDTO(appointment.getDoctor());
        this.patient = new UserDTO(appointment.getPatient());
        this.clinic = new ClinicDTO(appointment.getClinic());
    }
}
