package com.main.app.domain.model;

import com.main.app.domain.dto.HallDTO;
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
public class Hall extends AbstractEntity {

    @NotNull
    private String name;

    @NotNull
    private boolean isReserved;

    @ManyToOne
    private Clinic clinic;

    public Hall(@NotNull String name, Clinic clinic) {
        this.name = name;
        this.clinic = clinic;
        this.isReserved = false;
    }

    public Hall(HallDTO hall) {
        this.id = hall.getId();
        this.isReserved = hall.isReserved();
    }
}
