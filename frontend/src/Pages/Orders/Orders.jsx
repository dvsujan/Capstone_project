import React, { useEffect, useState } from "react";
import "./orders.css";
import axios from "axios";
import { parseJwt } from "../../global/Global";
import OrderCard from "../../Components/OrderCard/OrderCard";

const Orders = () => {
  const [orders, setOrders] = useState([]); 
  const fetchOrders = async()=>{ 
    const token = localStorage.getItem("token");
    const userId = parseJwt(token).UserId;
    const storeData = JSON.parse(localStorage.getItem("storeData"));
    const storeId = storeData.storeId;
    const headers = {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    };
    axios
      .get(
        `http://localhost:12150/api/Store/userorders?userId=${userId}&storeId=${storeId}`,
        { headers }
      )
      .then((response) => {
        setOrders(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  useEffect(() => { 
     fetchOrders();
    const intervalId = setInterval(fetchOrders, 5000);
    return () => clearInterval(intervalId);
    
  }, []);
  return (
    <div>
        <h1>Your Orders:</h1>
        {orders && orders.map((order) => <OrderCard order={order} />)}</div>
  );
};

export default Orders;
