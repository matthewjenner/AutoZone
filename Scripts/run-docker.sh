#!/bin/bash

# AutoZone Docker Compose Runner
echo "Starting AutoZone with Docker Compose..."

# Function to check if containers are healthy
check_containers() {
    echo "Checking container status..."
    docker compose ps
}

# Function to show logs
show_logs() {
    echo "Container logs:"
    docker compose logs --tail=20
}

# Stop any existing containers
echo "Stopping existing containers..."
docker compose down

# Build and start the services
echo "Building and starting services..."
docker compose up --build -d

# Wait a moment for containers to start
echo "Waiting for containers to start..."
sleep 10

# Check container status
check_containers

echo ""
echo "Services are starting..."
echo " | API will be available at: https://localhost:7000"
echo " | Frontend will be available at: https://localhost:3000"
echo " | SQL Server will be available at: localhost:1433"
echo ""

# Show logs
show_logs

echo ""
echo "Useful commands:"
echo " | View logs: docker compose logs -f"
echo " | Stop services: docker compose down"
echo " | Restart services: docker compose restart"
echo " | View container status: docker compose ps"
echo ""

# Function to cleanup on exit
cleanup() {
    echo ""
    echo "Stopping containers..."
    docker compose down
    echo "Cleanup complete"
    exit 0
}

# Set up signal handlers
trap cleanup SIGINT SIGTERM

echo "Press Ctrl+C to stop all services"
echo ""

# Keep script running and show logs
while true; do
    sleep 30
    echo ""
    echo "Container status:"
    check_containers
done 