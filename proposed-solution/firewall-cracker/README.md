## Installation

```bash
# Clone the repository
git clone https://github.com/yourusername/firewall-cracker.git
cd firewall-cracker

# Install dependencies
npm install
```

## Development

```bash
# Start the development server
npm run dev
```

Visit `http://localhost:5173` to view the application.

## Testing

```bash
# Run Jest tests
npm test
```

## Building for Production

```bash
# Create a production build
npm run build

# Preview the production build locally
npm run preview
```

## Packaging

The application is built using Vite, which creates optimized assets in the `dist` directory when you run `npm run build`. These assets can be deployed to any static hosting service.

### Deployment Options

1. **Static Hosting Services**
   - Netlify, Vercel, GitHub Pages, etc.
   - Simply point to your `dist` directory

2. **Docker Container**
   ```bash
   # Build Docker image
   docker build -t firewall-cracker .
   
   # Run container
   docker run -p 8080:80 firewall-cracker
   ```

3. **Manual Deployment**
   - Copy the contents of the `dist` directory to your web server