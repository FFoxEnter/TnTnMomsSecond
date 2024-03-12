using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class DataModel : Singleton<DataModel>
{
    [Serializable]
    public class Base
    {
        public string code;
        public int status;
        public JObject data;
    }

    [Serializable]
    public class BaseMultiData
    {
        public string code;
        public int status;
        public JToken data;
    }

    [Serializable]
    public class ErrerResponse
    {
        public int status;
        public ErrorData response;
    }

    [Serializable]
    public class ErrorData
    {
        public string code;
        public string message;
    }
   
    [Serializable]
    public class LoginInfo
    {
        /// <summary>
        /// 학생 아이디
        /// </summary>
        public string studentId;
        /// <summary>
        /// 학생 비밀번호
        /// </summary>
        public string password;
    }

    [Serializable]
    public class Token
    {
        public string accessToken;
        public string refreshToken;
        public string roles;
    }

    [Serializable, CanBeNull]
    public class UpdateMessage
    {
        public string dateTime;
        public string? session;
        public string? action;
        public string? type;
        public string? message;
        public string? userId;
    }

    [Serializable]
    public class Student
    {
        [Serializable, CanBeNull]
        public class StudentData
        {
            /// <summary>
            /// 인덱스(몇 번째)
            /// </summary>
            public string id;
            /// <summary>
            /// 학생 아이디
            /// </summary>
            public string studentId;
            /// <summary>
            /// 학생 비밀번호
            /// </summary>
            public string password;
            /// <summary>
            /// 학생 닉네임
            /// </summary>
            public string nickname;
            /// <summary>
            /// 학생 계정 메모
            /// </summary>
            public string memo;
            /// <summary>
            /// 승인 레벨(관리자가 변경)
            /// </summary>
            public int approvedLevel;
            /// <summary>
            /// 이전 레벨
            /// </summary>
            public int beforeLevel;
            /// <summary>
            /// 타입 검사
            /// </summary>
            public string typeInspection;
            /// <summary>
            /// 담당 선생님
            /// </summary>
            public Teacher userTeacher;
            /// <summary>
            /// (관리자가) 변경 레벨
            /// </summary>
            public int? adminChangeLevel;
        }

        [Serializable, CanBeNull]
        public class Teacher
        {
            /// <summary>
            /// 인덱스(몇 번째 선생님인지)
            /// </summary>
            public int id;
            /// <summary>
            /// 선생님 아이디
            /// </summary>
            public string? teacherId;
            /// <summary>
            /// 선생님 이름
            /// </summary>
            public string? nickname;
            /// <summary>
            /// 선생님 상세
            /// </summary>
            public string teacherAbout;
            /// <summary>
            /// 선생님 메모
            /// </summary>
            public string? memo;
            /// <summary>
            /// 프로필 이미지
            /// </summary>
            public ProfileImage? profileImage;
            public TeacherAboutImageList? teacherAboutImageList;
            public ScheduleList? scheduleList;
            //public UserCategoryList? userCategoryList;
        }

        [Serializable, CanBeNull]
        public class ProfileImage
        {
            /// <summary>
            /// 파일 인덱스
            /// </summary>
            public int? id;
            /// <summary>
            /// 파일 확장자
            /// </summary>
            public string? fileExtension;
            /// <summary>
            /// 파일 저장 경로
            /// </summary>
            public string? filePath;
            /// <summary>
            /// 실제 파일명
            /// </summary>
            public string? originFileName;
            /// <summary>
            /// 저장된 파일명
            /// </summary>
            public string? savedFileName;
            /// <summary>
            /// 이미지 url
            /// </summary>
            public string url;
        }

        [Serializable, CanBeNull]
        public class TeacherAboutImageList
        {
            public int id;
            public string fileExtension;
            public string filePath;
            public string originFileName;
            public string savedFileName;
            public string url;
        }

        [Serializable, CanBeNull]
        public class ScheduleList
        {
            public int id;
            public string fileExtension;
            public string filePath;
            public string originFileName;
            public string savedFileName;
            public string url;
        }

        [Serializable, CanBeNull]
        public class UserCategoryList
        {
            public int id;
            public string? title;
            public string? classification;
            public string? description;            
            public int? parentId;
            public string? createdAt;
        }

        [Serializable]
        public class Notice
        {
            public int id;
            public string title;
            public string content;
        }

    }

    [Serializable, CanBeNull]
    public class Schedule
    {
        [Serializable, CanBeNull]
        public class ScheduleData
        {
            public int id;
            public string? title;
            public int totalCompletionTime;
            public string? description;
            public ScheduleCategory? scheduleCategory;
            //public JObject? userStudentList;
            public Student.Teacher? userMentor;
            public Student.Teacher? userTeacher;
            //public JObject? scheduleColor;
            public string startDateTime;
            public string endDateTime;
            public int activityTime;
            public List<ActivityLogData>? activityDiaryList;
            public string createdAt;
            public List<ReviewList>? impressionList;
        }

        [Serializable, CanBeNull]
        public class ScheduleCategory
        {
            public int id;
            public string? title;
            public string? description;
            public int? parentId;
            public int? depth;
        }

        [Serializable, CanBeNull]
        public class ActivityLogData
        {
            public int id;
            //public ScheduleData? schedule;
            public Student.StudentData? userStudent;
            public string? content;
            public string? feelings;
            public string? startDateTime;
            public string? endDateTime;
            public int? activityTime;
            //public Student.Teacher? mentor;
            //public Student.Teacher? teacher;
            public List<ActivityDiaryCommentList>? activityDiaryCommentList;
            public string createdAt;

        }

        [Serializable]
        public class ActivityLog
        {
            public int scheduleIdx;
            public string content;
            public string feelings;
            public string startDateTime;
            public string endDateTime;
        }

        [Serializable]
        public class ModifiedActivityLog
        {
            public int activityDiaryIdx;
            public string content;
            public string feelings;
            public string startDateTime;
            public string endDateTime;
        }

        [Serializable]
        public class ActivityDiaryCommentList
        {
            public int id;
            public string comment;
        }

        [Serializable, CanBeNull]
        public class ReviewList
        {
            public int id;
            //public Schedule.ScheduleData schedule;
            public string? content;
            public List<ReviewCommentList>? commentList;
            public Student.Teacher? userTeacher;
            public string createdAt;
        }

        [Serializable]
        public class Review
        {
            public int scheduleIdx;
            public string content;
        }

        [Serializable]
        public class ModifiedReview
        {
            public int impressionIdx;
            public string content;
        }

        [Serializable]
        public class ReviewCommentList
        {
            public int id;
            public string comment;
        }


        [Serializable]
        public class Dday
        {
            public int dday;
        }

        [Serializable, CanBeNull]
        public class SelfRelianceData
        {
            [Serializable, CanBeNull]
            public class PreferredService
            {
                public int id;
                public string serviceName;
            }

            [Serializable, CanBeNull]
            public class CommentList
            {
                public int id;
                public string comment;
            }

            [Serializable, CanBeNull]
            public class Data
            {
                public int id;
                public object userStudent;
                public string goal;
                public string detailedPlan;
                public string createdAt;
                public string updatedAt;
                public List<CommentList>? independentLivingPlanCommentList;
                public List<PreferredService> preferredServiceList;
            }

            public class REQ_SelfRelianceWritePostData
            {
                public string goal;
                public string detailedPlan;
                public List<int> preferredList;
            }
        }
    }

    [Serializable, CanBeNull]
    public class PublicHolidayData
    {
        public string? resultCode;
        public string? resultMsg;
        public JObject Item;
        public int? numOfRows;
        public int? pageNo;
        public int? totalCount;
    }

    [System.Serializable, CanBeNull]
    public class VirtualSpaceMainImage
    {
        public int id;
        public string fileExtension;
        public string filePath;
        public string originFileName;
        public string savedFileName;
        public string url;
    }

    [System.Serializable, CanBeNull]
    public class VirtualSpaceMainVideoThumbnail
    {
        public int id;
        public string fileExtension;
        public string filePath;
        public string originFileName;
        public string savedFileName;
        public string url;
    }

    [System.Serializable, CanBeNull]
    public class VirtualSpaceMedia
    {
        public int id;
        public string title;
        public int location;
        public string url;
        public string memo;
        public string type;
        public VirtualSpaceMainImage[]? virtualSpaceMainImageList;
        public VirtualSpaceMainVideoThumbnail[]? virtualSpaceMainVideoThumbnailList;
    }

    [System.Serializable]
    public class Booth
    {
        public int id;
        public string title;
        public int vodCount;
        public int imageCount;
        public string backgroundUrl;
        public VirtualSpaceMedia[] virtualSpaceMediaList;
    }

    [System.Serializable]
    public class BoothData
    {
        public string code;
        public int status;
        public Booth[] data;
    }
}