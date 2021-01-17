package com.main.app.domain.dto;

import com.main.app.domain.model.Hall;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@Getter
@Setter
public class HallDTO {

    private Long id;
    private boolean isReserved;

    public HallDTO(Hall hall) {
        this.id = hall.getId();
        this.isReserved = hall.isReserved();
    }
}
