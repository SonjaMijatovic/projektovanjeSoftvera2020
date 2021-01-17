package com.main.app.domain.model;


import com.main.app.domain.dto.RecordDTO;
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
public class Record extends  AbstractEntity {

    private String description;

    @ManyToOne
    private User patient;

    public Record(String description, User user) {
        this.description = description;
        this.patient = user;
    }

    public Record(RecordDTO record) {
        this.id = record.getId();
        this.description = record.getDescription();
    }
}
