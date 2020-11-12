import React from 'react';
import { render } from '@testing-library/react';
import UserProfile from './UserProfile';

test('renders learn react link', () => {
  const { getByText } = render(<UserProfile />);
  const linkElement = getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
