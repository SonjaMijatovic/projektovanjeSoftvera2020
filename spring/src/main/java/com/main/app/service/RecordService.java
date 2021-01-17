package com.main.app.service;

import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Record;
import com.main.app.domain.model.user.User;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.List;

public interface RecordService {

    Page<Record> findAllByPatient(User patient, Pageable pageable);
    Record save(Record record);
}
