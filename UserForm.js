import React, { useState } from "react";
import axios from "axios";

const UserForm = () => {
    const [formData, setFormData] = useState({ name: "", email: "" });
    const [errors, setErrors] = useState({});

    const validate = () => {
        let errors = {};
        if (!formData.name) errors.name = "Name is required";
        if (!formData.email) errors.email = "Email is required";
        setErrors(errors);
        return Object.keys(errors).length === 0;
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (!validate()) return;
        try {
            await axios.post("/User/SubmitForm", formData);
            alert("Form submitted successfully!");
        } catch (error) {
            console.error("Error submitting form", error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Name:</label>
                <input type="text" value={formData.name} onChange={(e) => setFormData({...formData, name: e.target.value})} />
                {errors.name && <p>{errors.name}</p>}
            </div>
            <div>
                <label>Email:</label>
                <input type="email" value={formData.email} onChange={(e) => setFormData({...formData, email: e.target.value})} />
                {errors.email && <p>{errors.email}</p>}
            </div>
            <button type="submit">Submit</button>
        </form>
    );
};

export default UserForm;