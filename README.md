📅 Agenda Management API

This project is a multi-tenant agenda management API, designed to handle companies, agendas, employees and turn scheduling with configurable rules.

The system focuses on clean architecture, clear domain modeling, and business rules centralized in the service layer.

🚀 Features
Accounts

Create an account

Create a turn

Companies

Create a company

Hire an employee

Fire an employee

Manage multiple agendas per company

Agenda

Create an agenda

Define agenda rules

Dynamically generate available time slots based on agenda configuration

Prevent overlapping turns

⚙️ Business Rules Implemented

Accounts are unique by DNI / document number

Companies are unique by business name (not CUIT)

Turn slots are generated dynamically (no hardcoded times)

Overlapping turns are not allowed

Employees can belong to one or more agendas

Turns follow a lifecycle:

Pending

Confirmed

Cancelled

Completed

All business rules are handled in the service layer.
Controllers are limited to HTTP concerns only.

🏗️ Architecture Overview

The API follows a layered architecture:

Controllers
HTTP endpoints only (no business logic)

Services
Core business logic and validations

Repositories
Data access and persistence

DTOs & Mappers
Input/output models and transformations

This separation ensures maintainability, testability, and clear responsibility boundaries.

🔒 Pending Features / Roadmap

The following features are planned for future iterations:

Prevent clients from creating turns in the past

Restrict clients to view and manage only their own turns

Allow employees to manage all turns within their assigned agendas

Prevent turn creation outside agenda working hours

JWT-based authentication with role-based authorization

Agenda availability exceptions:

Holidays

Non-working days

Custom blocked time ranges

🧠 Design Goals

Clear domain modeling

No business rules inside controllers

Flexible agenda configuration

Multi-tenant support

Scalable foundation for future features

📌 Notes

This project is intended as a portfolio project, showcasing backend architecture, domain-driven design principles, and real-world scheduling logic.