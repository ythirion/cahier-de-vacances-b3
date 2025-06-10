export interface PasswordValidationResult {
  isValid: boolean;
  errors: string[];
}

export interface CheckPasswordRequest {
  password: string;
}

const API_URL = `${import.meta.env.VITE_MATRIX_API_URL}/api/password-check`;

export const validatePassword = async (password: string): Promise<PasswordValidationResult> => {
  try {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ password } as CheckPasswordRequest)
    });

    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return await response.json() as PasswordValidationResult;
  } catch (error) {
    console.error('Error validating password:', error);
    return {
      isValid: false,
      errors: ['Unable to connect.']
    };
  }
};