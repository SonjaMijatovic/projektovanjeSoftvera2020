package com.main.app.repository.user;

import com.main.app.domain.model.Appointment;
import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.Price;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface PriceRepository extends JpaRepository<Price, Long> {

    List<Price> findAllByClinic(Clinic clinic, Pageable pageable);
}
