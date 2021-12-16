export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'http://localhost:5001' : ''
export const useSockets = false
export const domain = 'kylee-marlin.us.auth0.com'
export const audience = 'https://CoolStuff.com'
export const clientId = 'mpXgASnPybMqw6Qp3lKxL9QNqXVp7ylk'