export interface ICompany {
    id: string;
   name: string;
   size: string;
   createdAt: string;
}

//Creating DTO for companies
export interface ICreateCompany {
   
   name: string;
   size: string;
   
}
// [
//     {
//       "id": 1,
//       "name": "Microsoft",
//       "size": "Large",
//       "createdAt": "2025-03-16T10:49:39.986075"
//     }
//   ]