using EvaluationSystem.Core.Domain.Common.Dtos;
using EvaluationSystem.Core.Domain.Common.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EvaluationSystem.Infra.DAL.SQL.Reporting.Repositories
{
    public class AdoReportRepository: IReportRepository
    {       
        private readonly SqlConnection sqlConnection;

        public AdoReportRepository(SqlConnection sqlConnection)
        {          
            this.sqlConnection = sqlConnection;
        }

        public List<EvaluationReportResultDetailDto> CollegeScoreReport(int userId)
        {
            var command = new SqlCommand();           
            command.Connection = sqlConnection; 
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Sp_CollegeScoreReport";
            command.Parameters.AddWithValue("@UserId", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);           
            var dt = new DataTable();
            adapter.Fill(dt);           
            return dt.AsEnumerable().Select(x => new EvaluationReportResultDetailDto
            {
                CollegeId=(int) x[nameof(EvaluationReportResultDetailDto.CollegeId)],
                CollegeName= x[nameof(EvaluationReportResultDetailDto.CollegeName)].ToString(),
                EvaluationIndexeId=(int) x[nameof(EvaluationReportResultDetailDto.EvaluationIndexeId)],
                EvaluationIndexeTitle= x[nameof(EvaluationReportResultDetailDto.EvaluationIndexeTitle)].ToString(),
                SumGrade= (int)x[nameof(EvaluationReportResultDetailDto.SumGrade)],
                SumWeight=(int)x[nameof(EvaluationReportResultDetailDto.SumWeight)],
                IndexWeight = (int)x[nameof(EvaluationReportResultDetailDto.IndexWeight)]
            }).ToList();            
        }
    }
}
