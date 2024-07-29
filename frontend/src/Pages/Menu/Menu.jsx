import React, {useState , useEffect} from 'react' 
import { Tab, Tabs, TabList, TabPanel } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';
import './menu.css'  
import { fetchWithTimeout } from '../../global/Global';


const Menu = async() => {   
    const [menuData, setMenuData]= useState();  
    useEffect( ()=>{    
        const fetchData = async()=>{
            try{
                const response = await fetchWithTimeout('http://localhost:12150/api/Menu');
                const data = await response.json();  
                console.log(data) ; 
                setMenuData(data);
            }catch(error){
                console.error('Error fetching data:', error);
            }
        }
        fetchData();
    },[]) 

  return (  
    <Tabs>
      <TabList>
        <Tab tabFor="vertical-tab-one">Tab 1</Tab>
        <Tab tabFor="vertical-tab-two">Tab 2</Tab>
      </TabList>

      <TabPanel tabId="vertical-tab-one">
        <p>Tab 1 content</p>
      </TabPanel>

      <TabPanel tabId="vertical-tab-two">
        <p>Tab content</p>
      </TabPanel>
    </Tabs>
  )
}

export default Menu