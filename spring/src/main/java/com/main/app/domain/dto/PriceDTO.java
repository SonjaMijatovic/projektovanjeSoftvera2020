package com.main.app.domain.dto;

import com.main.app.domain.model.Price;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@Getter
@Setter
public class PriceDTO {

    private Long id;
    private String description;
    private double price;

    public PriceDTO(Price price) {
        this.description = price.getDescription();
        this.price = price.getPrice();
        this.id = price.getId();
    }


}
