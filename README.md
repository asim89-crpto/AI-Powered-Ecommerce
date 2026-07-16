# 🚀 AI Powered Ecommerce Platform

A production-ready AI Powered Ecommerce web application built with **ASP.NET Core (.NET 10 Preview)**, **SQL Server**, **Docker**, **AWS EC2**, and **GitHub Actions CI/CD**.

---

# 📌 Project Overview

This project demonstrates the complete software development and deployment lifecycle.

It includes:

- ASP.NET Core Web Application
- Entity Framework Core
- SQL Server 2022
- ASP.NET Identity Authentication
- Docker Containerization
- Docker Compose
- AWS EC2 Deployment
- GitHub Actions Continuous Integration
- GitHub Actions Continuous Deployment

---

# 🛠️ Technologies Used

## Backend

- ASP.NET Core (.NET 10 Preview)
- C#
- Entity Framework Core
- SQL Server 2022
- ASP.NET Identity

## Frontend

- Razor Components (Blazor)
- Bootstrap 5

## DevOps

- Docker
- Docker Compose
- Git
- GitHub
- GitHub Actions

## Cloud

- AWS EC2
- Ubuntu Linux
- SSH

---

# 📂 Project Architecture

```
Developer
     │
 git push
     │
     ▼
GitHub Repository
     │
     ▼
GitHub Actions
     │
 ├── Checkout
 ├── Restore
 ├── Build
 ├── Publish
 ├── Docker Build
 └── SSH Deployment
          │
          ▼
AWS EC2
          │
     git pull
          │
docker compose down
          │
docker compose up -d --build
          │
          ▼
Live Application
```

---

# 📦 Docker Architecture

```
Docker Compose

├── ASP.NET Core Container
│
└── SQL Server Container
```

---

# ⚙️ Features

- User Registration & Login
- ASP.NET Identity Authentication
- Product Management
- Categories
- Shopping Cart
- SQL Server Database
- Entity Framework Core Migrations
- Automatic Database Initialization
- Responsive UI
- Dockerized Deployment
- Continuous Integration
- Continuous Deployment

---

# 🚀 Continuous Integration

Every push to the **main** branch automatically triggers GitHub Actions.

Pipeline Steps

- Checkout Repository
- Setup .NET
- Restore Packages
- Build Project
- Publish Application
- Build Docker Image

---

# 🚀 Continuous Deployment

After a successful build, GitHub Actions:

1. Connects to AWS EC2 using SSH.
2. Pulls the latest source code.
3. Stops running containers.
4. Rebuilds Docker images.
5. Starts updated containers.

Deployment commands executed automatically:

```bash
git pull origin main

docker compose down

docker compose up -d --build
```

No manual deployment is required.

---

# 📁 Project Structure

```
AI-Powered-Ecommerce

├── Components
├── Controllers
├── Data
├── Models
├── Services
├── wwwroot
├── Dockerfile
├── docker-compose.yml
├── Program.cs
└── .github
    └── workflows
        └── ci.yml
```

---

# 💻 Running Locally

Clone repository

```bash
git clone https://github.com/asim89-crpto/AI-Powered-Ecommerce.git
```

Restore packages

```bash
dotnet restore
```

Run project

```bash
dotnet run
```

---

# 🐳 Run with Docker

Build image

```bash
docker build -t ai-powered-ecommerce .
```

Run containers

```bash
docker compose up -d
```

---

# ☁️ Cloud Deployment

The application is deployed on:

- AWS EC2
- Ubuntu Linux
- Docker
- Docker Compose

---

# 🔄 CI/CD Workflow

Whenever code is pushed:

```
Developer
     │
git push
     │
     ▼
GitHub
     │
     ▼
GitHub Actions
     │
Build
     │
Docker Build
     │
SSH to EC2
     │
git pull
     │
docker compose up --build
     │
Live Website Updated
```

---

# 🔧 Problems Solved During Development

- SQL Server container memory limitation
- Docker networking
- SQL Server connection issues
- GitHub Actions workflow configuration
- Dockerfile build issues
- SSH authentication
- GitHub Secrets configuration
- AWS EC2 deployment
- Automatic EF Core database migrations

---

# 📈 Future Improvements

- Kubernetes
- Amazon EKS
- NGINX Reverse Proxy
- HTTPS with Let's Encrypt
- Docker Hub / GitHub Container Registry
- Terraform
- Prometheus & Grafana
- Serilog Logging

---

# 👨‍💻 Author

**Muhammad Asim**

GitHub

https://github.com/asim89-crpto

---

# ⭐ If you found this project useful, consider giving it a Star!