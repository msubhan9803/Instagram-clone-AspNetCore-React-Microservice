import React from 'react';
import { render } from '@testing-library/react';
import Signup from './Signup';

test('renders learn react link', () => {
  const { getByText } = render(<Signup />);
  const linkElement = getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
