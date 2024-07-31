import React, { useState, useEffect } from "react";
import { Tab, Tabs, TabList, TabPanel } from "react-tabs";
import "react-tabs/style/react-tabs.css";
import "./menu.css";
import { fetchWithTimeout } from "../../global/Global";
import axios from "axios";
import toast, { Toaster } from "react-hot-toast"; 
import ProductCategory from "../../Components/ProductCategory/ProductCategory";

const Menu = () => {
  const [menuData, setMenuData] = useState(null);
  useEffect(() => {
    axios
      .get("http://localhost:12150/api/Menu")
      .then((res) => {
        setMenuData(res.data);
      })
      .catch((err) => {
        toast.error("Error in fetching data");
        console.log(err);
      });
  }, []);
  
  return (
    <div className="vertical-tabs-container">
      {menuData && (
        <Tabs className="vertical-tabs">
          <TabList className="vertical-tablist">
            <h1>Categories</h1>
            {menuData.superCategories.map((item) => (
              <Tab key={item.id}>{item.name}</Tab>
            ))}
          </TabList>
          {menuData.superCategories.map((superCategory) => (
            <TabPanel key={superCategory.id} className="categories">
                <h1 className="category-name">{superCategory.name}</h1>
                {superCategory.categories.map((category)=>(
                    <ProductCategory key={category.id} category={category}/>
                ))}
            </TabPanel>
          ))}
          <Toaster />
        </Tabs>
      )}
    </div>
  );
};

export default Menu;
