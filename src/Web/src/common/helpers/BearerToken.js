import TokenChecker from './TokenChecker';

const BearerToken = () => {
    if (TokenChecker()) {
      const token = localStorage.getItem("token");

      return ("Bearer " + token);
    }
};

export default BearerToken;