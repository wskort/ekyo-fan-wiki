---
tags: Archief/ECT
---
# Purge all subscriptions for company
1. Connect to [[ECT VDI|VDI]]
2. Open [[RDCMan|RDCMan (Remote Desktop Connection Manager)]]
3. Connect to 055
4. Open [[SQL Server]] 
5. Connect to MSTCEN007. 
6. Find the CompanyId you want to purge, and use it in the code below: 

```sql
DELETE FROM RPProfiles.dbo.Mandates
  WHERE SubscriptionPaymentMethodId IN (
    SELECT Id FROM RPProfiles.dbo.SubscriptionPaymentMethods
    WHERE SubscriptionId IN (
      SELECT Id FROM RPProfiles.dbo.Subscriptions
      WHERE CompanyId = /*CompanyId*/));

DELETE FROM RPProfiles.dbo.SubscriptionPaymentMethods
  WHERE SubscriptionId IN (
    SELECT Id FROM RPProfiles.dbo.Subscriptions
	WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.SubscriptionProducts
  WHERE SubscriptionId IN (
    SELECT Id FROM RPProfiles.dbo.Subscriptions
	WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.SubscriptionSubscriptionPeriods
  WHERE SubscriptionId IN (
    SELECT Id FROM RPProfiles.dbo.Subscriptions
	WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.SubscriptionRenewalPeriods
  WHERE SubscriptionID IN (
    SELECT Id FROM RPProfiles.dbo.Subscriptions
    WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.Emails
  WHERE SubscriptionId IN (
    SELECT Id FROM RPProfiles.dbo.Subscriptions
	WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.InvoiceLines
  WHERE InvoiceId IN (
    SELECT Id FROM RPProfiles.dbo.Invoices
    WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.InvoicePdfs
  WHERE InvoiceId IN (
    SELECT Id FROM RPProfiles.dbo.Invoices
    WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.Requests
  WHERE TransactionId IN (
    SELECT Id FROM RPProfiles.dbo.Transactions
    WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.Transactions
  WHERE CompanyId = /*CompanyId*/;

DELETE FROM RPProfiles.dbo.Emails
  WHERE InvoiceId IN (
    SELECT Id FROM RPProfiles.dbo.Invoices
    WHERE CompanyId = /*CompanyId*/);

DELETE FROM RPProfiles.dbo.Invoices
  WHERE CompanyId = /*CompanyId*/;

DELETE FROM RPProfiles.dbo.Subscriptions
  WHERE CompanyId = /*CompanyId*/;
  

SELECT * FROM RPProfiles.dbo.Subscriptions
  WHERE CompanyId = /*CompanyId*/;
```
