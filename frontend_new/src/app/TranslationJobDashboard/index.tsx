import TranslationJobDto from "../Models/TranslationJobDto";

import "./index.css"


export default function TranslationJobDashboard({data}: {data: TranslationJobDto[]}){ 
  console.log("translated jobs", data)

 
  return (
    <table className="jobDashboard">
      <thead>
        <tr>
          <th>
            Id
          </th>
          <th>
            Status
          </th>
          <th>
            CustomerName
          </th>
          <th>
            OriginalContent
          </th>
          <th>
            TranslatedContent
          </th>
          <th>
            Price
          </th>
        </tr>
      </thead>
      <tbody>
        {data.map(e=>(
            <tr key={e.id}>
              <td>
                {e.id}
              </td>
              <td>
                {e.status}
              </td>
              <td>
                {e.customerName}
              </td>
              <td>
                {e.originalContent}
              </td>
              <td>
                {e.translatedContent}
              </td>
              <td>
                {e.price}
              </td>
            </tr>          
          ))}
        {data.length <= 0 && (
            <tr>
              <td colSpan={6}>... no data to show ...</td>
            </tr>
        )}
      </tbody>
    </table>
  )
}