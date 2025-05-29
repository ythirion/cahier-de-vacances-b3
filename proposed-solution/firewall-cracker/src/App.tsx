import { useState } from 'react';
import PasswordInput from './components/PasswordInput';
import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/tron-theme.css';

function App() {
  const [showSuccess, setShowSuccess] = useState(false);
  const [showAlarm, setShowAlarm] = useState(false);

  const handleSuccess = () => {
    setShowSuccess(true);
    setShowAlarm(false);
    
    // Hide success message after 4 seconds
    setTimeout(() => {
      setShowSuccess(false);
    }, 4000);
  };

  const handleError = () => {
    setShowAlarm(true);
    
    setTimeout(() => {
      setShowAlarm(false);
    }, 2000);
  };

  return (
    <div className={`tron-container ${showAlarm ? 'alarm-animation' : ''}`}>
      <div className="tron-grid"></div>
      
      {showSuccess && (
        <div className="success-message" style={{
          position: 'fixed',
          top: '20px',
          left: '0',
          width: '100%',
          textAlign: 'center',
          zIndex: 100
        }}>
          <div style={{
            display: 'inline-block',
            backgroundColor: 'rgba(0, 20, 30, 0.8)',
            color: 'var(--tron-success)',
            padding: '15px 30px',
            borderRadius: '5px',
            boxShadow: 'var(--tron-success-glow)',
            textShadow: '0 0 5px var(--tron-success)',
            fontFamily: 'var(--tron-font)',
            textTransform: 'uppercase',
            letterSpacing: '2px',
            animation: 'tron-success-pulse 2s infinite'
          }}>
            <p style={{ fontSize: '1.5rem', margin: 0 }}>Firewall Breached</p>
            <p style={{ fontSize: '1rem', marginTop: '5px', margin: 0 }}>System Access Granted</p>
          </div>
        </div>
      )}
      
      <div className="container">
        <div className="row justify-content-center">
          <div className="col-md-8 col-lg-6">
            <PasswordInput onSuccess={handleSuccess} onError={handleError} />
            
            <div className="mt-4 text-center">
              <p style={{ color: 'var(--tron-light)', fontSize: '0.8rem' }}>
                ENCOM International v2.0 • UNAUTHORIZED ACCESS PROHIBITED
              </p>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
