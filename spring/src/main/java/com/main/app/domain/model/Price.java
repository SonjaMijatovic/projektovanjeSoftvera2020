package com.main.app.domain.model;

import com.main.app.domain.dto.PriceDTO;
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
public class Price extends AbstractEntity {

    @NotNull
    private String description;

    @NotNull
    private double price;

    @ManyToOne
    private Clinic clinic;

    public Price (String description, double price, Clinic clinic) {
        this.description  =description;
        this.price = price;
        this.clinic = clinic;
    }

    public Price(PriceDTO price) {
        this.description = price.getDescription();
        this.price = price.getPrice();
        this.id = price.getId();
    }
}
