package com.main.app.domain.dto;

import com.main.app.domain.model.Record;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@NoArgsConstructor
@Getter
@Setter
public class RecordDTO {

    private Long id;
    private String description;

    public RecordDTO(Record record) {
        this.id = record.getId();
        this.description = record.getDescription();
    }
}
