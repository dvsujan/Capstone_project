import React, { useEffect, useState } from "react";
import { Tabs, TabList, Tab, TabPanel } from "react-tabs";
import "react-tabs/style/react-tabs.css";
import toast, { Toaster } from "react-hot-toast";
import axios from "axios";
import { parseJwt } from "../../global/Global";
import OrderCard from "../../Components/OrderCard/OrderCard";

const StorePage = () => {
  const [orders, setOrders] = useState(null);
  const [incomingOrders, setIncomingOrders] = useState(null);
  const [ongoingOrders, setOngoingOrders] = useState(null);

  const reFetchOrders = async () => {
    const token = localStorage.getItem("emp-token");
    const storeId = parseJwt(token).StoreId;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    axios
      .get(`http://localhost:12150/api/Store/orders?storeId=${storeId}`, config)
      .then((response) => {
        setOrders(response.data);
        setIncomingOrders(
          response.data.filter((order) => order.status === "Pending")
        );
        setOngoingOrders(
          response.data.filter((order) => order.status === "Accepted")
        );
      })
      .catch((error) => {
        toast.error(error.response.data.message);
      });
  };
  useEffect(() => {
    const intervalId = setInterval(reFetchOrders, 5000);

    return () => clearInterval(intervalId);
  }, []);
  const onAccept = async (orderId) => {
    const token = localStorage.getItem("emp-token");
    const storeId = parseJwt(token).StoreId;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    axios
      .post(
        `http://localhost:12150/api/Store/AcceptOrder?orderId=${orderId}&storeId=${storeId}`,
        {},
        config
      )
      .then(async (response) => {
        console.log(response.data);
        await reFetchOrders();
        toast.success("Accepted Order");
      })
      .catch((error) => {
        toast.error(error.response.data.message);
      });
  };
  const onReject = (orderId) => {
    const token = localStorage.getItem("emp-token");
    const storeId = parseJwt(token).StoreId;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    axios
      .post(
        `http://localhost:12150/api/Store/DeclineOrder?orderId=${orderId}&storeId=${storeId}`,
        {},
        config
      )
      .then(async (response) => {
        console.log(response.data);
        await reFetchOrders();
        toast.success("Accepted Declined");
      })
      .catch((error) => {
        toast.error(error.response.data.message);
      });
  };
  const onReady = (orderId) => {
    const token = localStorage.getItem("emp-token");
    const storeId = parseJwt(token).StoreId;
    const config = {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    };
    axios
      .post(
        `http://localhost:12150/api/Store/ReadyOrder?orderId=${orderId}&storeId=${storeId}`,
        {},
        config
      )
      .then(async (response) => {
        console.log(response.data);
        await reFetchOrders();
        toast.success("Order Ready");
      })
      .catch((error) => {
        toast.error(error.response.data.message);
      });
  };
  return (
    <div className="vertical-tabs-container">
      <Tabs className="vertical-tabs">
        <TabList className="vertical-tablist">
          <h1>Store</h1>
          <Tab>Incoming Orders</Tab>
          <Tab>Ongoing Orders</Tab>
        </TabList>
        <TabPanel className="categories">
          <h1 className="category-name" style={{ width: "50vw" }}>
            Incoming Orders
          </h1>
          {incomingOrders &&
            incomingOrders.map((order) => (
              <OrderCard
                key={order.orderId}
                order={order}
                store={true}
                accept={true}
                reject={true}
                onAccept={onAccept}
                onReject={onReject}
              />
            ))}
        </TabPanel>
        <TabPanel className="categories">
          <h1 className="category-name" style={{ width: "50vw" }}>
            Ongoing Orders
          </h1>
          {ongoingOrders &&
            ongoingOrders.map((order) => (
              <OrderCard
                key={order.orderId}
                order={order}
                store={true}
                ready={true}
                onReady={onReady}
              />
            ))}
        </TabPanel>
      </Tabs>
      <Toaster />
    </div>
  );
};

export default StorePage;
