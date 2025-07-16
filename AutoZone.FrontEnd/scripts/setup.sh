#!/bin/bash

echo "Setting up AutoZone Frontend..."

# Check if pnpm is installed
if ! command -v pnpm &> /dev/null; then
    echo "pnpm is not installed. Please install pnpm first:"
    echo "npm install -g pnpm"
    exit 1
fi

# Install dependencies
echo "Installing dependencies..."
pnpm install

# Check if installation was successful
if [ $? -eq 0 ]; then
    echo "   Dependencies installed successfully!"
    echo ""
    echo "   Setup complete! To start development:"
    echo "   pnpm run dev"
    echo ""
    echo "   Available commands:"
    echo "   pnpm run dev     - Start development server"
    echo "   pnpm run build   - Build for production"
    echo "   pnpm run preview - Preview production build"
    echo "   pnpm run lint    - Run ESLint"
else
    echo "❌ Failed to install dependencies"
    exit 1
fi 