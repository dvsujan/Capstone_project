import React, { useEffect, useState } from 'react'
import './cart.css'
import CartCard from '../../Components/CartCard/CartCard'

const Cart = () => { 
    const [selectedStore , setSelectedStore] = useState(null)
    const [cart , setCart] = useState([])
    useEffect(()=>{ 
        if (localStorage.getItem("storeData")!=null){ 
            const storeData = JSON.parse(localStorage.getItem("storeData")); 
            setSelectedStore(storeData); 
            console.log(selectedStore); 
        }
    },[])
  return ( 
    <div className='cart-screen'>
        <div className="cart-left">
            <div >

                <h1>Review Order</h1>
                <h4>Ready in Around 4-7 min</h4> 
                <div className='store-add' onClick={()=>{window.location.href="/store"}}>
                    {selectedStore?(<>{selectedStore.address}</>):(<>Select Store</>)}
                </div>
                <p>PickUp Method</p>
                <div >
                    <p>Instore</p>
                    <p>DriveThru</p>
                </div>

            </div>

        </div>
        <div className="cart-right">
            <CartCard/>
        </div>
    </div>
  )
}

export default Cart