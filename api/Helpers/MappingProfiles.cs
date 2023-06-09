﻿using api.Models.Dto;
using api.Models.Dto.Account;
using api.Models.Dto.Answer;
using api.Models.Dto.Class;
using api.Models.Dto.Question;
using api.Models.Dto.Role;
using api.Models.Dto.ScoreDto;
using api.Models.Entities;
using AutoMapper;

namespace api.Helpers;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        #region Class

        CreateMap<Class, GetClassDto>().ForMember(a => a.UsersDtos, src => src.MapFrom(x => x.Users));
        CreateMap<Class, GetUserClasses>();
        CreateMap<CreateClassDto, Class>();
        CreateMap<UpdateClassDto, Class>();
        CreateMap<GetClassDto, Class>();
        #endregion

        #region Role
        CreateMap<Role, GetRoleDto>();
        #endregion

        #region User
        CreateMap<User, GetAccountDto>();
        #endregion

        #region Question

        CreateMap<Question, GetQuestionDto>()
            .ForMember(dest=>dest.AnswersDtos,src=>src.MapFrom(x=>x.Answers))
            .ForMember(dest=>dest.Content ,src=>src.MapFrom(x=>x.Contents));
        CreateMap<CreateQuestionDto, Question>();
        CreateMap<UpdateQuestionDto, Question>();
        CreateMap<GetQuestionDto, Question>();
        #endregion

        #region Answer

        CreateMap<Answer, GetAnswerDto>();

        #endregion

        #region Score
        CreateMap<Score, GetScoreDto>().ForMember(a=>a.User,src=>src.MapFrom(x=>x.User)).ForMember(a=>a.QuizTitle,src=>src.MapFrom(x=>x.Quiz.Name));
        CreateMap<AddScoreDto, Score>();    
        #endregion
        #region Quiy

        CreateMap<Quiz, GetQuizDto>()
            .ForMember(dest=>dest.Questions,src=>src.MapFrom(x=>x.Questions))
            .ForMember(dest=>dest.User,src=>src.MapFrom(x=>x.User))
            .ForMember(dest=>dest.Class,src=>src.MapFrom(x=>x.Class));

        #endregion
    }
}