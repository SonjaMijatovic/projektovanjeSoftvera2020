package com.main.app.domain.dto;

import javax.validation.constraints.NotNull;

import com.main.app.domain.model.Clinic;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@Getter
@Setter
public class ClinicDTO
{
    private Long id;
    private String name;
    private String address;
    private String description;

    public ClinicDTO(Clinic clinic) {
        this.id = clinic.getId();
        this.name = clinic.getName();
        this.address = clinic.getAddress();
        this.description = clinic.getDescription();
    }
}
