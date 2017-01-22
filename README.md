# SINF_Sales-Force-Automation

A [CRM](https://pt.wikipedia.org/wiki/Customer_relationship_management) to manage a sales force team in order to automate it as much as possible, with the integration of the Primavera ERP. The main purpose of the app is to make the planning, scheduling and actual work of the sales force team more efficient.
The Web App has two types of users:
 1. Sales representatives
- Consult daily activities and places to visit
- Consult personal goal and KPI (key performance indicators)
- Consult list and details of clients
- Manage leads, activities and orders

 2. Sales managers
- Consult all items available for sales representatives
- Consult company and sales representative KPI
- Manage the goals of sales representative

For better understand this project don't hesitate to read our [final report](https://github.com/sergiomieic/SINF_Sales-Force-Automation/blob/master/FinalReport.pdf)

## System Architecture

![System Architecture](https://github.com/sergiomieic/SINF_Sales-Force-Automation/blob/master/deployment.png)


## Terms Definition
 1. Client - potential or known customer of the company, who may have previously completed transactions with PharmaLabs or not. To ease the work of the sales representative, PharmaCRM makes no distinction between prospect client/contact and effective client.
 2. Sales representative - employee who meets and negotiates with clients and potential targets. Represents the main user of the system, who wants to get and create tasks and see customer information.
 3. Sales manager - employee who manages the sales representatives by viewing the key performance indicators for both the company and specific sales representatives. Inside PharmaCRM, this employee is called the Administrator.
 4. Activity- appointment with a customer or potential target, which can be either presential (in either of the attendee’s offices) or via video call, phone call, email, proposal, task,commitment with client or proposal submission  (which is assumed to take place in the company’s employee’s office).
 5. Sales order - allocates stock and allows the client to purchase stock. This means that an agreement has been reached with a customer for the purchase of well-defined quantities of products for an agreed cost.
 6. Sale opportunity (lead) - represents an ongoing negotiation with a customer, for certain products at a certain price. There’s a possibility to reserve stock for a sales opportunity so that when an agreement is reached the opportunity can be converted into a sales order without the risk of insufficient stock.
