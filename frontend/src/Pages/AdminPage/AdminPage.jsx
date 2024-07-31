import React, { useEffect, useState } from "react";
import { Tabs, TabList, Tab, TabPanel } from "react-tabs";
import "react-tabs/style/react-tabs.css";
import toast, { Toaster } from "react-hot-toast";
import axios from "axios";

const AdminPage = () => { 
    const [categories, setCategories] = useState(null); 
    useEffect(()=>{
        toast.promise(  
            axios.get("http://localhost:12150/api/Product/Categories").then((res)=>{
            setCategories(res.data)
        }),{
            loading:"Loading...",
            error:"Error Fetching Categories"
        }
        )
    },[])
  return (
    <div className="vertical-tabs-container">
      <Tabs className="vertical-tabs">
        <TabList className="vertical-tablist">
          <h1>Admin</h1>
          <Tab>Dasboard</Tab>
          <Tab>AddProduct</Tab>
        </TabList>
        <TabPanel className="categories">
          <h1 className="category-name" style={{ width: "50vw" }}>
            Dashboard
          </h1>
        </TabPanel>
        <TabPanel className="categories">
          <h1 className="category-name" style={{ width: "50vw" }}>
            AddProduct
          </h1>
          <form className="AddProductForm">
            <input type="text" placeholder="Product Name" />
            <input type="text" placeholder="Product Price" />
            <input type="text" placeholder="Product Description" />
            <input type="file"  placeholder="Product Image" /> 
            <select name="category" id="category"> 
               <option value="">Select Category</option> 
              {categories?.map((category) => (
                <option value={category.categoryId}>{category.categoryName}</option>
              ))}
            </select>
            <button type="submit">Add Product</button>
            <br />
          </form>
        </TabPanel>
      </Tabs>
      <Toaster />
    </div>
  );
};

export default AdminPage;
