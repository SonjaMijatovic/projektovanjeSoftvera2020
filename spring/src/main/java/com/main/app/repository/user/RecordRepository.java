package com.main.app.repository.user;

import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.Record;
import com.main.app.domain.model.user.User;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface RecordRepository extends JpaRepository<Record, Long> {

    Page<Record> findAllByPatient(User patient, Pageable pageable);
}
