const TokenChecker = () => {
    const token = localStorage.getItem("token");
    const tokenExpiry = localStorage.getItem("expires");
    var timeStamp = Math.floor(new Date().getTime() / 1000);

    if (token && tokenExpiry) {      
      if (timeStamp < tokenExpiry) {
        return true;
      } else {
        console.log("Token is expired");
        localStorage.removeItem("token");
        localStorage.removeItem("expires");
        return false;
      }
    } else {
      return null;
    }
};

export default TokenChecker;