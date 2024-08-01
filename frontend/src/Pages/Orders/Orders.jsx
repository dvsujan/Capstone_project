import React, { useEffect, useState } from "react";
import "./orders.css";
import axios from "axios";
import { parseJwt } from "../../global/Global";
import OrderCard from "../../Components/OrderCard/OrderCard";
import toast, { Toaster } from "react-hot-toast";

const Orders = () => {
  const [orders, setOrders] = useState([]);
  const fetchOrders = async () => {
    const token = localStorage.getItem("token");
    const userId = parseJwt(token).UserId;
    const storeData = JSON.parse(localStorage.getItem("storeData"));
    const storeId = storeData.storeId;
    const headers = {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    }; 
    toast.promise(
    axios
      .get(
        `${process.env.REACT_APP_API}/api/Store/userorders?userId=${userId}&storeId=${storeId}`,
        { headers }
      )
      .then((response) => {
        setOrders(response.data);
      })
      .catch((error) => {
        console.log(error);
      })
      ,{
        loading: 'Loading orders...',
        success: 'Orders Refreshed',
        error: 'Failed to fetch orders',
      }
    ); 
  };

  useEffect(() => {
    fetchOrders();
    const intervalId = setInterval(fetchOrders, 5000);
    return () => clearInterval(intervalId);
  }, []);
  return (
    <div>
      <h1>Your Orders:</h1>
      {orders && orders?.toReversed().map((order) => <OrderCard order={order} />)}
      <Toaster />
    </div>
  );
};

export default Orders;
