package com.main.app.repository.user;

import com.main.app.domain.model.user.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.sql.Timestamp;
import java.util.Optional;

/**
 * JPA repository for management of the User entity.
 *
 */
@Repository
public interface UserRepository extends JpaRepository<User, Long> {

    Optional<User> findOneByEmail(String email);
    Optional<User> findOneByRegistrationToken(String token);
    User save(User user);
    Optional<User> findOneByResetTokenAndResetTokenExpirationDateAfter(String resetToken, Timestamp now);
    Optional<User> findOneById(Long id);
}