package com.main.app.service;

import com.main.app.domain.model.Record;
import com.main.app.domain.model.user.User;
import com.main.app.repository.user.RecordRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class RecordServiceImpl implements RecordService {

    private RecordRepository recordRepository;

    @Autowired
    public RecordServiceImpl(RecordRepository recordRepository) {
        this.recordRepository = recordRepository;
    }

    @Override
    public Page<Record> findAllByPatient(User patient, Pageable pageable) {
        return recordRepository.findAllByPatient(patient, pageable);
    }

    @Override
    public Record save(Record record) {
        return recordRepository.save(record);
    }
}
